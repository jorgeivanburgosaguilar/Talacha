import React from "react";

function ListItem(props) {
    return (
        <li>
            {props.value} <code>(Key: {props.key2})</code>
        </li>
    );
}

export default ListItem;
