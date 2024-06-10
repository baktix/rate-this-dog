import './StarControl.css';

//import star from '/assets/star.svg';
//TODO: switch out the SVG path reuse for a shared img src
//TODO: we can probably build the trail recusively so it reads better

export function StarControl() {
    return (
        <>
            <div className="starControl">
                <svg className="template">
                    <defs>
                        <symbol id="starPath">
                            <path d="M26.285,2.486l5.407,10.956c0.376,0.762,1.103,1.29,1.944,1.412l12.091,1.757
                                c2.118,0.308,2.963,2.91,1.431,4.403l-8.749,8.528c-0.608,0.593-0.886,1.448-0.742,2.285l2.065,12.042
                                c0.362,2.109-1.852,3.717-3.746,2.722l-10.814-5.685c-0.752-0.395-1.651-0.395-2.403,0l-10.814,5.685
                                c-1.894,0.996-4.108-0.613-3.746-2.722l2.065-12.042c0.144-0.837-0.134-1.692-0.742-2.285l-8.749-8.528
                                c-1.532-1.494-0.687-4.096,1.431-4.403l12.091-1.757c0.841-0.122,1.568-0.65,1.944-1.412l5.407-10.956
                                C22.602,0.567,25.338,0.567,26.285,2.486z" />
                        </symbol>
                    </defs>
                </svg>

                <div className="trail">
                    <input name="rating" type="radio" className="btn btn-link star" id="star1" aria-label="One Star" />
                    <label htmlFor="star1"><svg viewBox="0 0 50 50">
                        <use href="#starPath" />
                    </svg></label>
                    <div className="trail">
                        <input name="rating" type="radio" className="btn btn-link star" id="star2" aria-label="Two Stars" />
                        <label htmlFor="star2"><svg viewBox="0 0 50 50">
                            <use href="#starPath" />
                        </svg></label>
                        <div className="trail">
                            <input name="rating" type="radio" className="btn btn-link star" id="star3" aria-label="Three Stars" />
                            <label htmlFor="star3"><svg viewBox="0 0 50 50">
                                <use href="#starPath" />
                            </svg></label>
                            <div className="trail">
                                <input name="rating" type="radio" className="btn btn-link star" id="star4" aria-label="Four Stars" />
                                <label htmlFor="star4"><svg viewBox="0 0 50 50">
                                    <use href="#starPath" />
                                </svg></label>
                                <div className="trail">
                                    <input name="rating" type="radio" className="btn btn-link star" id="star5" aria-label="Five Stars" />
                                    <label htmlFor="star5"><svg viewBox="0 0 50 50">
                                        <use href="#starPath" />
                                    </svg></label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>{/*starControl*/}
        </>
    );
}