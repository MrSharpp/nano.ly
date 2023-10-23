export function setCookies(accessToken: string, refreshToken: string) {
    document.cookie = `accessToken=${accessToken}; path=/`
    document.cookie = `refreshToken=${refreshToken}; path=/`
}
