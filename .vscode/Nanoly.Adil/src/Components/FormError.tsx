import { Text } from "@mantine/core";

export function FormError({message}: {message: string}){

    return <Text c="red">{message}</Text>
}