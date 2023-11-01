/* eslint-disable @typescript-eslint/no-unused-vars */
import {
    TextInput,
    PasswordInput,
    Checkbox,
    Anchor,
    Paper,
    Title,
    Text,
    Container,
    Group,
    Button,
} from '@mantine/core'
import classes from './Identity.module.css'
import { useNavigate } from 'react-router-dom'
import { useForm, zodResolver } from '@mantine/form'
import { useMutation } from '@tanstack/react-query'
import { ErrorResolve } from '../../utils/apiErrorResolver'
import { SignupApi } from './Identity.api'
import { ISignupSchema, SignupSchema } from './Identity.schema'
import { SetAuthPersistant } from './Identity.util'
import { useEffect } from 'react'
import { useAuth } from '../../Providers/AuthProvider'

export function SIgnup() {
    const navigate = useNavigate()
    const { login, isAuthenticated } = useAuth()

    useEffect(() => {
        if (isAuthenticated) navigate('/dashboard')
    }, [isAuthenticated])

    const signupForm = useForm<ISignupSchema>({
        validate: zodResolver(SignupSchema),
    })

    const signupMutation = useMutation({
        mutationFn: SignupApi,
        onError(data) {
            const error = ErrorResolve(data.response)

            if (!error)
                return signupForm.setFieldError('email', 'something went wrong')

            if (error.key != null)
                return signupForm.setFieldError(error.key, error.message)

            if (error.message)
                return signupForm.setFieldError('email', error.message)
        },
        onSuccess(data, variables, context) {
            SetAuthPersistant(data.accessToken, data.refreshToken)
            login()
        },
    })

    return (
        <Container size={420} my={40}>
            <Title ta="center" className={classes.title}>
                Welcome back!
            </Title>
            <Text c="dimmed" size="sm" ta="center" mt={5}>
                Already have an account?{' '}
                <Anchor
                    size="sm"
                    component="button"
                    onClick={() => navigate('/login')}
                >
                    Login
                </Anchor>
            </Text>

            <form
                onSubmit={signupForm.onSubmit((vals) => {
                    const { confirmPassword, ...rest } = vals
                    signupMutation.mutate(rest)
                })}
            >
                <Paper withBorder shadow="md" p={30} mt={30} radius="md">
                    <TextInput
                        label="Email"
                        placeholder="you@mantine.dev"
                        {...signupForm.getInputProps('email')}
                    />

                    <PasswordInput
                        label="Password"
                        placeholder="Your password"
                        mt="md"
                        {...signupForm.getInputProps('password')}
                    />

                    <PasswordInput
                        label="Confirm Password"
                        placeholder="Your password"
                        mt="md"
                        {...signupForm.getInputProps('confirmPassword')}
                    />

                    <Group justify="space-between" mt="lg">
                        <Checkbox label="Remember me" />
                        <Anchor component="button" size="sm">
                            Forgot password?
                        </Anchor>
                    </Group>
                    <Button fullWidth mt="xl" type="submit">
                        Sign up
                    </Button>
                </Paper>
            </form>
        </Container>
    )
}
