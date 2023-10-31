import { Link, NavLink } from "react-router-dom";
const Home = () => {
  return (
    <>
      <header>
        <a href="#">Logo</a>
        <nav>
          <ul>
            <li>
              <NavLink to="/">Home</NavLink>
            </li>
            <li>
              <NavLink to="/about">About</NavLink>
            </li>
            <li>
              <NavLink to="/contact">Contact</NavLink>
            </li>
          </ul>
        </nav>
      </header>
      <section>
        <p>Welcome to Home Page!</p>
      </section>
    </>
  );
};
export default Home;
