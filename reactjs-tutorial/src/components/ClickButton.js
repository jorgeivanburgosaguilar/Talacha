import React from "react";

function ClickButton(props) {
    return <button onClick={props.onClick}>{props.text}</button>;
}

export default ClickButton;
