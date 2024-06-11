import 'bootstrap/dist/css/bootstrap.css';
import './App.css';

import { Header } from './components/Header';
import { Footer } from './components/Footer';

import { DogRatingPage } from './components/DogRatingPage';

function App() {
  // const [count, setCount] = useState(0)

  return (
    <>
      <Header />
      <DogRatingPage />
      <Footer />
    </>
  );
}

export default App;
