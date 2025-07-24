export interface TaskInfo {
  id?: string;
  title?: string;
  description?: string;
}

export interface TaskResponse {
  task?: TaskInfo[];
}
