import axios, { AxiosResponse } from "axios";

const XSRF_TOKEN_KEY = "xsrfToken";
const XSRF_TOKEN_NAME_KEY = "xsrfTokenName";

function reportError(message: string, response: AxiosResponse) {
    const formattedMessage = `${message} : Status ${response.status} ${response.statusText}`
    console.log(formattedMessage);
}

function setToken({ token, tokenName }: { token: string, tokenName: string }) {
    window.sessionStorage.setItem(XSRF_TOKEN_KEY, token);
    window.sessionStorage.setItem(XSRF_TOKEN_NAME_KEY, tokenName);
    axios.defaults.headers.common[tokenName] = token;
}

export function initializeXsrfToken() {
    let token = "" //window.sessionStorage.getItem(XSRF_TOKEN_KEY);
    let tokenName = "" // window.sessionStorage.getItem(XSRF_TOKEN_NAME_KEY);

    if (!token || !tokenName) {
        axios.get("/api/xsrfToken/get")
            .then(r => setToken(r.data))
            .catch(r => reportError("Could not fetch XSRFTOKEN", r));
    } else {
        // setToken({ token: token, tokenName: tokenName });
    }
}