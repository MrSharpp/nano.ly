import { Routes, Route } from "react-router-dom";
import Home from "./Components/Home";
import Error from "./Components/Error";
import BlogComponent from "./Components/BlogComponent";
function App() {
  return (
    <>
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/blog/:id" element={<BlogComponent />} />
        <Route path="*" element={<Error />} />
      </Routes>
    </>
  );
}

export default App;
