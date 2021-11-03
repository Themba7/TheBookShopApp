export interface IServiceResponse<T> {
    IsSuccess: boolean,
    Time: Date,
    Message: string,
    Data: T
}
