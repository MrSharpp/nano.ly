import { BrowserRouter, Routes } from 'react-router-dom'
import { Login } from './Features/Authentication/Login'
import '@mantine/core/styles.css'

function App() {
    if (true) return <Login />

    return (
        <BrowserRouter>
            <Routes></Routes>
        </BrowserRouter>
    )
}

export default App
