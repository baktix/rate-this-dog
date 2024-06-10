export function ControlHeader(props) {
    const { imgSrc } = props;

    return (
        <>
            <h2>Check out this woofer</h2>
            <div className="w-100 bg-primary">
                <img src={imgSrc}
                    className="dog img-fluid w-100" />
            </div>
        </>
    );
}