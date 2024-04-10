using System;

public class RefrigeratedContainer {
    public string StoredProduct { get; private set; }
    public double CurrentTemperature { get; private set; }

    public RefrigeratedContainer(string product, double initialTemperature) {
        StoredProduct = product;
        CurrentTemperature = initialTemperature;
    }

    public void LoadCargo(string product, double initialTemperature) {
        if (StoredProduct == null) {
            StoredProduct = product;
            CurrentTemperature = initialTemperature;
        } else {
            if (StoredProduct != product) {
                throw new InvalidOperationException("Container can only store products of the same type.");
            }
            if (CurrentTemperature < GetRequiredTemperature(product)) {
                throw new InvalidOperationException("Temperature of the container cannot be lower than required.");
            }
        }
    }

    public void UnloadCargo() {
        StoredProduct = null;
        CurrentTemperature = 0.0;
    }

    public void ReplaceCargo(string newProduct, double newTemperature) {
        if (StoredProduct == null) {
            throw new InvalidOperationException("Container is empty.");
        }
        StoredProduct = newProduct;
        CurrentTemperature = newTemperature;
    }

    private double GetRequiredTemperature(string product) {
        switch (product) {
            case "Apples":
                return 5.0;
            case "Oranges":
                return 4.0;
            default:
                throw new ArgumentException("Unknown product.");
        }
    }

    public void PrintContainerInfo() {
        if (StoredProduct != null) {
            Console.WriteLine($"Container with product: {StoredProduct}, Temperature: {CurrentTemperature}");
        } else {
            Console.WriteLine("Container is empty.");
        }
    }
}
