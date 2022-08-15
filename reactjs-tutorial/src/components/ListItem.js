import React from 'react';

function ListItem(props) {
    return (
        <li>{props.value} {props.key2}</li>
    );
}

export default ListItem;