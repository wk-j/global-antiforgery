import * as React from "react"
import * as ReactDOM from "react-dom"
import axios from "axios"
import { initializeXsrfToken } from "./token";

type State = {
    message: string
}

initializeXsrfToken()

class App extends React.Component<{}, State> {

    constructor(props) {
        super(props)
        this.state = { message: "?" }
    }

    onClick = async (e) => {
        try {
            let rs = await axios.post<{ message: string }>("/api/hello/who", {
                name: "wk-j"
            })

            this.setState({
                message: rs.data.message
            });
        } catch (err) {
            this.setState({ message: err.message })
        }
    }

    render() {
        return (
            <div>
                <h1>Hello, world</h1>
                <button onClick={this.onClick}>Who</button>
                <h1>{this.state.message}</h1>
            </div>
        );
    }
}

var el = document.getElementById("root")
ReactDOM.render(<App />, el)