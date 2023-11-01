/* eslint-disable @typescript-eslint/no-explicit-any */
import {
    BrowserRouter,
    Navigate,
    Route,
    Routes,
    useNavigate,
} from 'react-router-dom'
import '@mantine/core/styles.css'
import { useAuth } from './Providers/AuthProvider'
import { Login } from './Features/Identity/Login'
import { SIgnup } from './Features/Identity/Signup'
import { useEffect } from 'react'
import { RefreshToken } from './Features/Identity/Identity.api'
import { SetAuthPersistant } from './Features/Identity/Identity.util'
import { getProfile } from './Providers/profile.api'
import { isAccessTokenExpired } from './utils/axios.util'
import { RootLayout } from './Layout/RootLayout'
import { Home } from './Features/Home/home'

const PrivateRoute = ({ children }) => {
    const { isAuthenticated } = useAuth()

    if (!isAuthenticated) return <Navigate to={'/login'} />

    return children
}

function App() {
    const { login, logout } = useAuth()

    const validateAuthenticaiton = async (): Promise<any> => {
        const profile = await getProfile()

        if (profile != false) {
            login()
        }

        if (isAccessTokenExpired() == true) {
            const tokens = await RefreshToken(
                localStorage.getItem('refreshToken') as unknown as string,
                localStorage.getItem('accessToken') as unknown as string
            ).catch(() => false)

            if (tokens != false) {
                SetAuthPersistant(tokens.accessToken, tokens.refreshToken)
                return validateAuthenticaiton()
            }
            logout()
        }
    }

    useEffect(() => {
        validateAuthenticaiton()
    }, [])

    return (
        <BrowserRouter>
            <Routes>
                <Route path="/" element={<Home />}></Route>
                <Route path="/app" element={<RootLayout />}>
                    <Route
                        path="dashboard"
                        element={
                            <PrivateRoute>
                                <h1>helloworld</h1>
                            </PrivateRoute>
                        }
                    />
                </Route>

                <Route path="/login" element={<Login />} />
                <Route path="/signup" element={<SIgnup />} />
            </Routes>
        </BrowserRouter>
    )
}

export default App
