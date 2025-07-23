export interface TaskInfo {
  id?: number;
  completed?: boolean;
  details?: string;
}

export interface TaskResponse {
  task?: TaskInfo[];
}
