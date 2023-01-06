import "./App.css";
import Greet from "./components/Greet";
import Clock from "./components/Clock";
import LoginControl from "./components/LoginControl";
import MyList from "./components/MyList";
import NameForm from "./components/NameForm";
import Calculator from "./components/Calculator";
import { PRODUCTS } from "./mocks/Products";
import FilterableProductTable from "./components/ThinkingInReact";

function App() {
    const numbers = [1, 2, 3, 4, 5, 6];
    return (
        <div className="App">
            <Greet>
                <Clock timezone={1} />
                <Clock timezone={2} />
                <Clock timezone={3} />
                <LoginControl />
                <MyList elements={numbers} />
                <NameForm />
            </Greet>
            <Calculator />
            <FilterableProductTable products={PRODUCTS} />
        </div>
    );
}

export default App;
