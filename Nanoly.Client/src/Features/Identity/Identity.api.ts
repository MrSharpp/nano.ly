import { axiosInstance } from "../../utils/axios.util";
import { ILoginSchema, ISignupSchema } from "./Identity.schema";

export async function LoginApi(body: ILoginSchema){
    return axiosInstance.post("/auth/login", body)
}

export async function SignupApi(body: ISignupSchema){
    return axiosInstance.post("/auth/signup", body)
}