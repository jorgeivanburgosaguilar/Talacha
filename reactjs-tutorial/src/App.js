//import logo from './logo.svg';
import './App.css';
import { Greet } from './components/Greet'
import { Clock } from './components/Clock'
import { LoginControl } from './components/LoginControl';
import MyList from './components/MyList';

function App() {
  const numbers = [1, 2, 3, 4, 5, 6];
  return (
    <div className="App">
      <LoginControl />
      <Greet />
      <Clock timezone={1} />
      <Clock timezone={2} />
      <Clock timezone={3} />
      <MyList elements={numbers} />
    </div>
  );
}

export default App;