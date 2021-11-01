import React, { PureComponent } from "react";
import 'bootstrap/dist/css/bootstrap.min.css';

import "./MusicItem.css"

export default class MusicItem extends PureComponent {

    render() {
        return (
            <div key={this.props.key}>
                <div className="card MusicItem" >
                    <div className="row">
                        <div className="col-md-1"><img className="img-rounded" height="100" width="100" src={this.props.imageUrl} alt="" /></div>
                        <div className="card-body col-md-9">
                            <h5 className="card-title">{this.props.author}</h5>
                            <p className="card-text">{this.props.songName}</p>
                        </div>
                    </div>
                </div>
                <br />
            </div>
        )
    }
}