import { AppShell, Burger, Button } from '@mantine/core'
import { useState } from 'react'
import { Outlet, useNavigate } from 'react-router-dom'

export function RootLayout() {
    const [opened, setOpenned] = useState(false)

    const navigate = useNavigate()

    const toggle = () => setOpenned(!opened)

    return (
        <AppShell
            header={{ height: 60 }}
            navbar={{
                width: 300,
                breakpoint: 'sm',
                collapsed: { mobile: !opened },
            }}
            padding="md"
        >
            <AppShell.Header>
                <div onClick={() => navigate('/')}>Home</div>
            </AppShell.Header>

            <AppShell.Navbar p="md">
                <Button>Logout</Button>
            </AppShell.Navbar>

            <AppShell.Main>
                <Outlet />
            </AppShell.Main>
        </AppShell>
    )
}
