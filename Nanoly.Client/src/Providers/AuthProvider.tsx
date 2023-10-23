import {
    createContext,
    useContext,
    useEffect,
    useLayoutEffect,
    useState,
} from 'react'
import { getProfile } from './profile.api'

const AuthContext = createContext({
    isAuthenticated: false,
    login: () => {},
    logout: () => {},
})

export function AuthProvider({ children }) {
    const [isAuthenticated, setIsAuthenticated] = useState(false)

    useEffect(() => {
        getProfile()
            .then((_) => login())
            .catch((_) => logout())
    }, [])

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
