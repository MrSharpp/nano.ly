import { Link, Outlet } from "react-router-dom";
const Header = () => {
  return (
    <>
      <header
        style={{
          display: "flex",
          justifyContent: "space-between",
          borderColor: "black",
          borderWidth: "1px",
          borderStyle: "solid",
          padding: "1rem 2rem",
        }}
      >
        <p style={{ fontSize: 24 }}>Logo</p>
        <nav>
          <ul
            style={{
              display: "flex",
              listStyleType: "none",
              gap: "2rem",
            }}
          >
            <li>
              <Link style={{ textDecoration: "none", fontSize: 24 }} to="/">
                Home
              </Link>
            </li>
            <li>
              <Link
                style={{ textDecoration: "none", fontSize: 24 }}
                to="/about"
              >
                About
              </Link>
            </li>
            <li>
              <Link
                style={{ textDecoration: "none", fontSize: 24 }}
                to="/contact"
              >
                Contact
              </Link>
            </li>
          </ul>
        </nav>
      </header>
      <Outlet />
    </>
  );
};

export default Header;
