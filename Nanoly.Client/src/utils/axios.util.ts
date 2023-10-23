import axios from 'axios'

const axiosInstance = axios.create({
    baseURL: 'http://localhost:5122/api',
})

export function isAccessTokenExpired() {
    const token = JSON.parse(
        atob((localStorage.getItem('accessToken') || '').split('.')[1])
    )

    if (!token) return false

    if (token.exp < Date.now()) return true
    return false
}

export { axiosInstance }
