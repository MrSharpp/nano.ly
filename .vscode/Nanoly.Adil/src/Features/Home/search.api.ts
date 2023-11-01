import { axiosInstance } from '../../utils/axios.util'

export function searchApi(spaceName: string) {
    return axiosInstance
        .get(`spaceName/find/${spaceName}`)
        .then((res) => res.data)
}
