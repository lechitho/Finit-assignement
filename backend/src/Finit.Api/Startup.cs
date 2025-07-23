using Finit.API.Extensions.Middleware;
using Finit.Application.Handlers;
using Finit.Application.Mappers;
using Finit.Application.Services;
using Finit.Application.Services.Interface;
using Finit.Domain.Tasks;
using Finit.Domain.Tasks.Commands;
using Finit.Domain.Tasks.Events;
using Finit.Domain.Tasks.Interface;
using Finit.Infrastructure.Factories;
using Finit.Infrastructure.Repositories;
using FluentMediator;
using Jaeger;
using Jaeger.Samplers;
using OpenTracing;
using OpenTracing.Util;
using Serilog;
using System.Reflection;

namespace Finit.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddScoped<ITaskService, TaskService>();
            services.AddSingleton<TaskViewModelMapper>();
            services.AddTransient<ITaskFactory, EntityFactory>();
            services.AddSingleton<ITaskRepository, TaskRepository>();
            services.AddScoped<TaskCommandHandler>();
            services.AddScoped<TaskEventHandler>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddFluentMediator(builder =>
            {
                builder.On<CreateNewTaskCommand>().PipelineAsync().Return<TaskInfo, TaskCommandHandler>((handler, request) => handler.HandleNewTask(request));
                builder.On<UpdateTaskCommand>().PipelineAsync().Return<TaskInfo, TaskCommandHandler>((handler, request) => handler.HandleUpdateTask(request));
                builder.On<DeleteTaskCommand>().PipelineAsync().Call<TaskCommandHandler>((handler, request) => handler.HandleDeleteTask(request));

                builder.On<TaskCreatedEvent>().PipelineAsync().Call<TaskEventHandler>((handler, request) => handler.HandleTaskCreatedEvent(request));
                builder.On<TaskUpdatedEvent>().PipelineAsync().Call<TaskEventHandler>((handler, request) => handler.HandleTaskUpdatedEvent(request));
                builder.On<TaskDeletedEvent>().PipelineAsync().Call<TaskEventHandler>((handler, request) => handler.HandleTaskDeletedEvent(request));
            });

            services.AddSingleton(serviceProvider =>
            {
                var serviceName = Assembly.GetEntryAssembly().GetName().Name;

                var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();

                ISampler sampler = new ConstSampler(true);

                ITracer tracer = new Tracer.Builder(serviceName)
                    .WithLoggerFactory(loggerFactory)
                    .WithSampler(sampler)
                    .Build();

                GlobalTracer.Register(tracer);

                return tracer;
            });

            Log.Logger = new LoggerConfiguration().CreateLogger();

            services.AddOptions();

            services.AddMvc();

            services.AddSwaggerGen();

            services.AddCors(options =>
            {
                options.AddPolicy("api", policy =>
                {
                    policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors("api");

            app.UseAuthorization();

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseStaticFiles();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Tasks API V1");
            });


        }
    }
}
