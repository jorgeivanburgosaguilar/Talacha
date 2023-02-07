import React, { Component } from "react";

class ProductCategoryRow extends Component {
    render() {
        const category = this.props.category;
        return (
            <tr>
                <th colSpan="2">{category}</th>
            </tr>
        );
    }
}

class ProductRow extends Component {
    render() {
        const product = this.props.product;
        const name = product.stocked ? (
            product.name
        ) : (
            <span style={{ color: "red" }}>{product.name}</span>
        );

        return (
            <tr>
                <td>{name}</td>
                <td>{product.price}</td>
            </tr>
        );
    }
}

class ProductTable extends Component {
    render() {
        const allowCaseInsensitive = this.props.allowCaseInsensitive;
        const filterText = allowCaseInsensitive
            ? this.props.filterText.toLowerCase()
            : this.props.filterText;
        const inStockOnly = this.props.inStockOnly;

        const rows = [];
        let lastCategory = null;

        this.props.products.forEach((product) => {
            let productName = allowCaseInsensitive
                ? product.name.toLowerCase()
                : product.name;
            if (productName.indexOf(filterText) === -1) {
                return;
            }
            if (inStockOnly && !product.stocked) {
                return;
            }
            if (product.category !== lastCategory) {
                rows.push(
                    <ProductCategoryRow
                        category={product.category}
                        key={product.category}
                    />
                );
            }
            rows.push(<ProductRow product={product} key={product.name} />);
            lastCategory = product.category;
        });

        return (
            <table>
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Price</th>
                    </tr>
                </thead>
                <tbody>{rows}</tbody>
            </table>
        );
    }
}

class SearchBar extends Component {
    constructor(props) {
        super(props);
        this.handleFilterTextChange = this.handleFilterTextChange.bind(this);
        this.handleInStockChange = this.handleInStockChange.bind(this);
        this.handleAllowCaseInsensitive =
            this.handleAllowCaseInsensitive.bind(this);
    }

    handleFilterTextChange(e) {
        this.props.onFilterTextChange(e.target.value);
    }

    handleInStockChange(e) {
        this.props.onInStockOnlyChange(e.target.checked);
    }

    handleAllowCaseInsensitive(e) {
        this.props.onAllowCaseInsensitive(e.target.checked);
    }

    render() {
        return (
            <form>
                <input
                    type="text"
                    placeholder="Search..."
                    value={this.props.filterText}
                    onChange={this.handleFilterTextChange}
                />
                <p>
                    <input
                        type="checkbox"
                        checked={this.props.inStockOnly}
                        onChange={this.handleInStockChange}
                    />{" "}
                    Only show products in stock
                </p>
                <p>
                    <input
                        name="AllowCaseInsensitive"
                        type="checkbox"
                        checked={this.props.allowCaseInsensitive}
                        onChange={this.handleAllowCaseInsensitive}
                    />{" "}
                    Allow Case Insensitive
                </p>
            </form>
        );
    }
}

class FilterableProductTable extends Component {
    constructor(props) {
        super(props);
        this.state = {
            filterText: "",
            inStockOnly: false,
            allowCaseInsensitive: false,
        };

        this.handleFilterTextChange = this.handleFilterTextChange.bind(this);
        this.handleInStockOnlyChange = this.handleInStockOnlyChange.bind(this);
        this.handleAllowCaseInsensitive =
            this.handleAllowCaseInsensitive.bind(this);
    }

    handleFilterTextChange(filterText) {
        this.setState({
            filterText: filterText,
        });
    }

    handleInStockOnlyChange(inStockOnly) {
        this.setState({
            inStockOnly: inStockOnly,
        });
    }

    handleAllowCaseInsensitive(allowCaseInsensitive) {
        this.setState({
            allowCaseInsensitive: allowCaseInsensitive,
        });
    }

    render() {
        return (
            <div>
                <SearchBar
                    filterText={this.state.filterText}
                    inStockOnly={this.state.inStockOnly}
                    onFilterTextChange={this.handleFilterTextChange}
                    onInStockOnlyChange={this.handleInStockOnlyChange}
                    onAllowCaseInsensitive={this.handleAllowCaseInsensitive}
                />
                <ProductTable
                    products={this.props.products}
                    filterText={this.state.filterText}
                    inStockOnly={this.state.inStockOnly}
                    allowCaseInsensitive={this.state.allowCaseInsensitive}
                />
            </div>
        );
    }
}

export default FilterableProductTable;
