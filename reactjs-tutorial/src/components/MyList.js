import React, { Component } from 'react';
import ListItem from './ListItem';

export class MyList extends Component {
    render() {
        return (
            <ul>
                {
                    this.props.elements.map(number =>
                        <ListItem key={number.toString()} key2={number.toString()} value={number} />
                    )
                }
            </ul>
        );
    }
}

export default MyList;