import { ActionIcon, Container, Flex, Text, TextInput } from '@mantine/core'
import { useForm } from '@mantine/form'
import { IconSearch } from '@tabler/icons-react'
import { useQuery } from '@tanstack/react-query'
import { searchApi } from './search.api'

export function Home() {
    const searchForm = useForm({
        initialValues: {
            spaceName: '',
        },
    })

    const searchQuery = useQuery({
        queryKey: [searchForm.values.spaceName],
        enabled: false,
        queryFn: () => searchApi(searchForm.values.spaceName),
    })

    const search = () => {
        searchQuery.refetch()
    }

    console.log(searchQuery.data)

    return (
        <Container>
            <Flex mt={'xl'} direction={'column'} gap={'xl'} align={'center'}>
                <Text
                    size={'xl'}
                    fw={900}
                    c={'#2C2E33'}
                    // variant="gradient"
                    mt={'xl'}
                    // gradient={{ from: 'blue', to: 'cyan', deg: 90 }}
                    style={{
                        fontSize: 75,
                        textAlign: 'center',
                    }}
                >
                    Find Your All In One 🚪 To Virtual You
                </Text>
                <TextInput
                    size="xl"
                    placeholder="Search a word... eg: mrsharp"
                    w={400}
                    rightSection={
                        <ActionIcon
                            variant="gradient"
                            size={'lg'}
                            onClick={search}
                        >
                            <IconSearch
                                size={'xs'}
                                style={{ width: '70%', height: '70%' }}
                            />
                        </ActionIcon>
                    }
                    {...searchForm.getInputProps('spaceName')}
                />
            </Flex>
        </Container>
    )
}
