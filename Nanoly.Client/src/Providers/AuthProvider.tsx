import {
    createContext,
    useContext,
    useEffect,
    useLayoutEffect,
    useState,
} from 'react'
import { getProfile } from './profile.api'
import { isAccessTokenExpired } from '../utils/axios.util'
import { RefreshToken } from '../Features/Identity/Identity.api'
import { SetAuthPersistant } from '../Features/Identity/Identity.util'

const AuthContext = createContext({
    isAuthenticated: false,
    login: () => {},
    logout: () => {},
})

export function AuthProvider({ children }) {
    const [isAuthenticated, setIsAuthenticated] = useState(false)

    useEffect(() => {
        validateAuthenticaiton()
    }, [])

    const validateAuthenticaiton = async () => {
        const profile = await getProfile()

        if (profile != false) return login()

        if (isAccessTokenExpired() == true) {
            const tokens = await RefreshToken(
                localStorage.getItem('refreshToken') as unknown as string,
                localStorage.getItem('accessToken') as unknown as string
            ).catch(() => false)

            if (tokens != false)
                return SetAuthPersistant(
                    tokens.accessToken,
                    tokens.refreshToken
                )
            validateAuthenticaiton()
        }

        logout()
    }

    const login = () => {
        setIsAuthenticated(true)
    }

    const logout = () => {
        setIsAuthenticated(true)
    }

    return (
        <AuthContext.Provider value={{ isAuthenticated, login, logout }}>
            {children}
        </AuthContext.Provider>
    )
}

export function useAuth() {
    return useContext(AuthContext)
}
