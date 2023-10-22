/* eslint-disable @typescript-eslint/no-explicit-any */
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
import {useForm, zodResolver } from '@mantine/form'
import { ILoginSchema, LoginSchema } from './Identity.schema'
import { useMutation } from '@tanstack/react-query'
import { LoginApi } from './Identity.api'
import { ErrorResolve } from '../../utils/apiErrorResolver'

export function Login() {

    const loginForm = useForm<ILoginSchema>({
        validate: zodResolver(LoginSchema)
    })

    const loginMutation = useMutation({
        mutationFn: LoginApi,
        onError(data){
            const error = ErrorResolve(data.response);
            
            if(!error) return alert("something went wrong");

            loginForm.setFieldError(error.key, error?.message);
        }
    })

    return (
        <Container size={420} my={40}>
            <Title ta="center" className={classes.title}>
                Welcome back!
            </Title>
            <Text c="dimmed" size="sm" ta="center" mt={5}>
                Do not have an account yet?{' '}
                <Anchor size="sm" component="button">
                    Create account
                </Anchor>
            </Text>

        <form onSubmit={loginForm.onSubmit(vals => loginMutation.mutate(vals))}>
            <Paper withBorder shadow="md" p={30} mt={30} radius="md">
                <TextInput
                    label="Email"
                    placeholder="you@mantine.dev"
                    required
                    {...loginForm.getInputProps("email")}
                />
                <PasswordInput
                    label="Password"
                    placeholder="Your password"
                    required
                    mt="md"
                    {...loginForm.getInputProps("password")}

                />
                <Group justify="space-between" mt="lg">
                    <Checkbox label="Remember me" />
                    <Anchor component="button" size="sm">
                        Forgot password?
                    </Anchor>
                </Group>
                <Button fullWidth mt="xl" type='submit'>
                    Sign in
                </Button>
            </Paper>
            </form>
        </Container>
    )
}
