import { axiosInstance } from "../../utils/axios.util";
import { ILoginSchema, ISignupSchema } from "./Identity.schema";

export async function LoginApi(body: ILoginSchema){
    return axiosInstance.post("/auth/login", body).then((res) => res.data)
}

export async function SignupApi(body: Omit<ISignupSchema, 'confirmPassword'>){
    return axiosInstance.post("/auth/signup", body).then((res) => res.data)
}