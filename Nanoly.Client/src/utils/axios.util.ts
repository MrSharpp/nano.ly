import axios from 'axios'

const axiosInstance = axios.create({
    baseURL: "http://localhost:5122/api",
});

export {axiosInstance};