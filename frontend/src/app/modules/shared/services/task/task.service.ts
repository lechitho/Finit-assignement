import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {BehaviorSubject, Observable, tap} from "rxjs";
import {TaskInfo} from "../../../../models/task";
import {CacheService} from "../cache/cache.service";
import {CACHE_KEYS} from "../../../../models/cache-keys";

@Injectable({
  providedIn: 'root'
})
export class TaskService {

  private baseUrl: string = "https://localhost:7200/api";

  constructor(private client: HttpClient, private cache: CacheService) { }

  public getTasks(): Observable<TaskInfo[]> {
    this.cache.removeData(CACHE_KEYS.TASKS);
    const tasks = this.cache.getData(CACHE_KEYS.TASKS);
    if (tasks) {
      return new BehaviorSubject<TaskInfo[]>(JSON.parse(tasks));
    }
    return this.client.get<TaskInfo[]>(this.baseUrl + "/Task").pipe(tap(v => this.cache.saveData(CACHE_KEYS.TASKS, JSON.stringify(v))));
  }

  public getTask(id: string): Observable<TaskInfo> {
    return this.client.get<TaskInfo>(this.baseUrl + "/Task/" + id);
  }

  public createTask(body: any): Observable<TaskInfo> {
    this.cache.removeData(CACHE_KEYS.TASKS);
    return this.client.post<TaskInfo>(this.baseUrl + "/Task", body);
  }

  public updateTask(id: string, body: any): Observable<any> {
    this.cache.removeData(CACHE_KEYS.TASKS);
    return this.client.put<any>(this.baseUrl + "/Task/" + id, body);
  }

  public deleteTask(id: string): Observable<any> {
    this.cache.removeData(CACHE_KEYS.TASKS);
    return this.client.delete(this.baseUrl + "/Task/" + id);
  }
}
