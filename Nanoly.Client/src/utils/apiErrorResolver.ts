/* eslint-disable @typescript-eslint/no-explicit-any */
export function ErrorResolve(axiosResponse: unknown): {key: string | null, message: string} | null{
    const errors = (axiosResponse  as any)?.data?.errors
    const appError = (axiosResponse  as any)?.data?.error as {code: string, message: string};

    if(!errors || Object.keys(errors).length < 1) {
        if(appError){
            return {
                key: null,
                message: appError.message
            };
        }
    }

    const key = Object.keys(errors).pop() as string

    return {
        key: key.toLocaleLowerCase(),
        message: errors[key]
    }
}