import React, { PureComponent } from "react";
import 'bootstrap/dist/css/bootstrap.min.css';

export default class Form extends PureComponent {
    render() {
        return (
            <form onSubmit={this.props.searchMusic}>
                <div className="form-group">
                    <input type="text" className="form-control" id="queryInput" placeholder="Song or artist name" onChange={this.props.handleQueryChange} />
                </div>
                <div className="input-group">
                    <select width="50%" className="form-control" id="exampleFormControlSelect1" onChange={this.props.handleGenreChange}>
                        <option></option>
                        <option>rock</option>
                        <option>blues</option>
                        <option>pop</option>
                        <option>metal</option>
                        <option>techno</option>
                    </select>
                    <input width="50%" type="number" className="form-control" id="queryInput" placeholder="Year" onChange={this.props.handleYearChange} />
                </div>
                <br />
                <button type="submit" className="btn btn-primary">Search</button>
            </form>
        );
    }
}