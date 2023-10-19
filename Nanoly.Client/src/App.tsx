import { BrowserRouter, Navigate, Route, Routes } from 'react-router-dom'
import '@mantine/core/styles.css'
import { useAuth } from './Providers/AuthProvider'
import { Login } from './Features/Identity/Login'

function App() {
    const { isAuthenticated } = useAuth()

    return (
        <BrowserRouter>
            {isAuthenticated ? <PublicRoutes /> : <PrivateRoutes />}
        </BrowserRouter>
    )
}

function PublicRoutes() {
    return (
        <Routes>
            <Route path="/" Component={() => 'This is'} />
        </Routes>
    )
}
function PrivateRoutes() {
    return (
        <Routes>
            <Route path="" element={Navigate({ to: '/login' })} />
            <Route path="/login" element={<Login />} />
        </Routes>
    )
}

export default App
