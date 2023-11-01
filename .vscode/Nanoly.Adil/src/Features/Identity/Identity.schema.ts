import z from 'zod'

const LoginSchema = z.object({
    email: z.string().email(),
    password: z.string()
})

interface ILoginSchema extends z.infer<typeof LoginSchema> {}

export { LoginSchema }
export type { ILoginSchema }

const SignupSchema = z.object({
    email: z.string().email(),
    password: z.string(),
    confirmPassword: z.string()
}).refine((data) => data.password == data.confirmPassword, {message: "Passwords do not match", path: ['password']})

interface ISignupSchema extends z.infer<typeof SignupSchema> {}

export { SignupSchema }
export type { ISignupSchema }
