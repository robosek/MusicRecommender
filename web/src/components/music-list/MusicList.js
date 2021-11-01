import React, { PureComponent } from "react";
import MusicItem from "../music-item/MusicItem"
import 'bootstrap/dist/css/bootstrap.min.css';

export default class MusicList extends PureComponent {

    render() {
        return (
            <div>
                <br />
                {
                    this.props.musicItems.map((musicItem, index) =>
                        <MusicItem key={index} imageUrl={musicItem.imageUrl} author={musicItem.artist} songName={musicItem.songName} />)
                }
            </div>
        )
    }
}