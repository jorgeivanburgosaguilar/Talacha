import React from "react";

export function ClickButton(props) {
    return <button onClick={props.onClick}>{props.text}</button>;
}

export default ClickButton;
