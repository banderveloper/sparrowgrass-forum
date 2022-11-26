import './styles/App.css';
import Navbar from "./components/Navbar";
import MainForm from "./components/MainForm";
import RecordList from "./components/RecordList";

function App() {
    return (
        <div>
            <Navbar/>
            <MainForm/>
            <RecordList/>
        </div>
    );
}

export default App;
