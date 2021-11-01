import React, { PureComponent } from "react";
import Header from "./components/header/Header"
import Form from "./components/form/Form"
import MusicList from "./components/music-list/MusicList"
import 'bootstrap/dist/css/bootstrap.min.css';

import "./App.css"
import config from "./config.json";

export default class App extends PureComponent {
    constructor(props) {
        super(props);
        this.state = {
            query: "",
            year: "",
            genre: "",
            recommendations: []
        };
    }

    handleQueryChange = event => {
        this.setState({
            query: event.target.value,
        });
    };

    handleYearChange = event => {
        this.setState({
            year: event.target.value,
        });
    };

    handleGenreChange = event => {
        this.setState({
            genre: event.target.value,
        });
    };

    searchMusic = (e) => {
        var requestPath = `${config.recommendationApiEndpoint}?`

        if (this.state.query !== "")
            requestPath += `Query=${this.state.query}&`

        if (this.state.year !== "")
            requestPath += `Year=${this.state.year}&`

        if (this.state.genre !== "")
            requestPath += `Genre=${this.state.genre}&`

        requestPath += `Market=PL`


        fetch(new Request(requestPath))
            .then(response => {
                if (!response.ok) {
                    throw Error(response.statusText)
                }

                return response.json()
            })
            .then(data => {
                console.log(data);
                this.setState({ recommendations: data.result.recommendations })

            })
            .catch(error => {
                console.log(error)
            })
        e.preventDefault();
    }

    render() {
        return (
            <div>
                <nav className="navbar navbar-light bg-dark">
                    <a className="navbar-brand" href="#">
                        <p className="Navbar">Music recommender</p>
                    </a>
                </nav>
                <div className="container App">
                    <Header />
                    <Form searchMusic={this.searchMusic} handleQueryChange={this.handleQueryChange} handleYearChange={this.handleYearChange} handleGenreChange={this.handleGenreChange} />
                    <MusicList musicItems={this.state.recommendations} />
                </div>
            </div>

        );
    }
}