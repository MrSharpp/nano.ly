/* eslint-disable @typescript-eslint/no-explicit-any */
export function ErrorResolve(axiosResponse: unknown): {key: string, message: string} | null{
    const errors = (axiosResponse  as any)?.data?.errors
    
    if(Object.keys(errors).length < 1) return null

    const key = Object.keys(errors).pop() as string

    return {
        key: key.toLocaleLowerCase(),
        message: errors[key]
    }
}