import { ActionIcon, Container, Flex, Text, TextInput } from '@mantine/core'

export function Home() {
    return (
        <Container>
            <Flex mt={'xl'} direction={'column'} gap={'xl'}>
                <Text
                    size={'xl'}
                    fw={900}
                    variant="gradient"
                    mt={'xl'}
                    gradient={{ from: 'blue', to: 'cyan', deg: 90 }}
                    style={{
                        fontSize: 75,
                        textAlign: 'center',
                    }}
                >
                    Find Your Nano Link
                </Text>
                <TextInput
                    size="xl"
                    placeholder="Search a word... eg: mrsharp"
                    rightSection={<ActionIcon />}
                />
            </Flex>
        </Container>
    )
}
