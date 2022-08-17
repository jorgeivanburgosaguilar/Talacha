import React from "react";

const Greet = (props) => (
    <React.Fragment>
        <h1>
            Hello World {new Date().getFullYear()}
        </h1>

        <div>
            {props.children}
        </div>
    </React.Fragment>
);

export default Greet;
