import { axiosInstance } from '../utils/axios.util'

export function getProfile() {
    return axiosInstance.get('/profile/me').then((res) => res.data)
}
