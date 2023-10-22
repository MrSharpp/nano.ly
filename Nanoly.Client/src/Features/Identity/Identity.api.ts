import { axiosInstance } from "../../utils/axios.util";

interface ILogin {
    email: string;
    password: string;
}

export function login(body: ILogin){
    return axiosInstance.post("/login", body)
}

export function signup(body: ILogin){
    return axiosInstance.post("/signup", body)
}