import logo from '../assets/logo.svg';

export function Header() {
  return (
    <header>
      <h1>
        <img className="logo"
          src={logo} />Rate This Dog
      </h1>
    </header>
  );
}
