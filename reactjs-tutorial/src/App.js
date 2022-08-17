import "./App.css";
import Greet from "./components/Greet";
import Clock from "./components/Clock";
import LoginControl from "./components/LoginControl";
import MyList from "./components/MyList";
import NameForm from "./components/NameForm";
import Calculator from "./components/Calculator";

function App() {
    const numbers = [1, 2, 3, 4, 5, 6];
    return (
        <div className="App">
            <Calculator />
            <LoginControl />
            <Greet>
                <NameForm />
                <MyList elements={numbers} />
                <Clock timezone={1} />
                <Clock timezone={2} />
                <Clock timezone={3} />
            </Greet>
        </div>
    );
}

export default App;
