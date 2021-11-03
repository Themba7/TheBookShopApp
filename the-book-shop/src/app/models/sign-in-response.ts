import { User } from "./user";

export interface SignInResponse {
    IsAuthSuccessful: boolean;
    ErrorMessage: string;
    Token: string;
    User: User;
}
