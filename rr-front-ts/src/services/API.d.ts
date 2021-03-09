declare namespace API {
  export interface SuccessResponse<T> {
    errorCode: number;
    resultData: T;
  }

  export interface List<T> {
    items: T[];
    page: number;
    pageSize: number;
    total: number;
  }
}
