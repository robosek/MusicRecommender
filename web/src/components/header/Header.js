import React, { PureComponent } from "react";
import 'bootstrap/dist/css/bootstrap.min.css';

import "./Header.css"

export default class Header extends PureComponent {

    render() {
        return (
            <h1 className="text-center Header">Search music</h1>
        )
    }
}