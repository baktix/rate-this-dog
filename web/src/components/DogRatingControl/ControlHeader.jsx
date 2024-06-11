export function ControlHeader({ imageUrl, averageRating }) {
    return (
        <>
            <h2>Check out this woofer</h2>
            <p>Rated {averageRating?.toFixed(2) ?? "0.00*"} by our members</p>
            <div className="w-100 bg-primary">
                <img src={imageUrl}
                    className="dog img-fluid w-100" />
            </div>
        </>
    );
}