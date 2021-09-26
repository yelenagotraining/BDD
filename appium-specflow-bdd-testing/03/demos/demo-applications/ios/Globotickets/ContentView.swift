//
//  ContentView.swift
//  Globotickets
//
//  Created by Marko Vajs on 22.6.21..
//

import SwiftUI

extension UIApplication {
    func endEditing() {
        sendAction(#selector(UIResponder.resignFirstResponder), to: nil, from: nil, for: nil)
    }
}

struct ContentView: View {
    private static var venues = [
        VenueItem(id: 0, title: "City Hall", price: 2500, capacity: 200),
        VenueItem(id: 1, title: "Main Building", price: 5000, capacity: 400),
        VenueItem(id: 2, title: "Retro Lounge", price: 7000, capacity: 500)
    ]
    private static var serviceLevels = [
        ServiceLevel(id: 0, title: "Basic", price: 100),
        ServiceLevel(id: 1, title: "Premium", price: 150),
    ]
    
    @State private var numberOfGuests = ""
    @State private var selectedVenueIndex = 0;
    @State private var selectedServiceLevelIndex = 0;
    @State private var promotionIncluded = false
    @State private var upfrontPayment = false
    @State private var upfrontPaymentPercentage = ""
    
    @State private var resultText = ""
    @State private var hasErrors = false
    @State private var isLoading = false
    
    private func resetState() {
        numberOfGuests = ""
        selectedVenueIndex = 0
        selectedServiceLevelIndex = 0
        promotionIncluded = false
        upfrontPayment = false
        upfrontPaymentPercentage = ""
    }
    
    private func resetValidationErrors() {
        hasErrors = false
        resultText = ""
    }
    
    private func setValidationError(message: String) {
        hasErrors = true;
        setResult(message: message);
    }
    
    private func setResult(message: String) {
        resultText = message;
    }
    
    private func validateForm() {
        resetValidationErrors()
        
        if ((Int(numberOfGuests) == nil) || (upfrontPayment == true && (Int(upfrontPaymentPercentage) == nil))) {
            setValidationError(message: "Please enter all data.")
            return;
        }
        
        if (ContentView.venues[selectedVenueIndex].capacity < Int(numberOfGuests) ?? 10000) {
            setValidationError(message: "Selected venue cannot accept the desired number of guests.")
            return;
        }
    }
    
    private static func calculateDiscount(paymentPercentage: Int) -> Double {
        if (paymentPercentage > 9) {
            return 0.9
        }
        
        if (paymentPercentage > 49) {
            return 0.8
        }
        
        return 1.0
    }
    
    private static func calculateTotalCost(numberOfGuests: Double, venue: VenueItem, service: ServiceLevel, promotion: Bool, paymentPercentage: Int) -> Double {
        return (numberOfGuests * service.price + venue.price) * calculateDiscount(paymentPercentage: paymentPercentage) + (promotion ? 500.0 : 0)
    }
    
    
    
    var body: some View {
        NavigationView {
            Form {
                Section(header: Text("Guest Information")) {
                    TextField("Number of Guests", text: $numberOfGuests, onCommit: {
                        UIApplication.shared.endEditing()
                    }) .keyboardType(.numbersAndPunctuation).accessibilityIdentifier("NumberOfGuests")
                }
                
                Section(header: Text("Venue Information")) {
                    Picker(selection: $selectedVenueIndex, label: Text("Venue")) {
                        ForEach(ContentView.venues) { venue in
                            Text(venue.title)
                                .accessibilityIdentifier("venueItem")
                        }
                    }.accessibilityIdentifier("VenueInformation")
                    Picker(selection: $selectedServiceLevelIndex, label: Text("Service Level")) {
                        ForEach(ContentView.serviceLevels) { serviceLevel in
                            Text(serviceLevel.title)
                                .accessibilityIdentifier("serviceLevelItem")
                        }
                    }.accessibilityIdentifier("ServiceLevel")
                    Toggle("Promotion Included", isOn: $promotionIncluded)
                        .accessibilityIdentifier("Promotion")
                }
                Section(header: Text("Payment Information")) {
                    Toggle("Upfront Payment", isOn: $upfrontPayment)
                        .onChange(of: upfrontPayment) { value in
                            if (value == false) {
                                upfrontPaymentPercentage = ""
                            }
                        }.accessibilityIdentifier("UpfrontPayment")
                    TextField("% Upfront Payment", text: $upfrontPaymentPercentage, onCommit: {
                        UIApplication.shared.endEditing()
                    }).keyboardType(.numbersAndPunctuation).disabled(!upfrontPayment)
                }.accessibilityIdentifier("UpfrontPaymentPercentage")
                
                Section(header: Text("Result")) {
                    HStack {
                        Text(resultText)
                            .foregroundColor(hasErrors ? .red : .blue)
                            .frame(minWidth: 0, maxWidth: .infinity, alignment: hasErrors ? .center : .leading)
                            .accessibilityIdentifier("Result")
                        if(isLoading) {
                            ProgressView().accessibilityIdentifier("CalculationInProgress")
                        }
                    }
                }
                
                Button("Calculate") {
                    resetValidationErrors()
                    validateForm()
                    
                    if (hasErrors) {
                        return;
                    }
                    
                    isLoading = true;
                    
                    let randomTime = Int.random(in: 2..<6)
                    
                    let dispatchAfter = DispatchTimeInterval.seconds(randomTime)

                    DispatchQueue.main.asyncAfter(deadline: DispatchTime.now() + dispatchAfter, execute: {
                        let result = ContentView.calculateTotalCost(numberOfGuests: Double(numberOfGuests)!, venue: ContentView.venues[selectedVenueIndex], service: ContentView.serviceLevels[selectedServiceLevelIndex], promotion: promotionIncluded, paymentPercentage: Int(upfrontPaymentPercentage) ?? 0);
                        
                        setResult(message: "Total cost is: $" + String(result));
                        isLoading = false;
                    })
                    
                }.frame(minWidth: 0, maxWidth: .infinity, alignment: .center)
                .accessibilityIdentifier("Calculate")
                
                Button("Clear") {
                    resetState();
                    resetValidationErrors();
                }.frame(minWidth: 0, maxWidth: .infinity, alignment: .center)
                .accessibilityIdentifier("Clear")
                
            }
            .navigationBarTitle("Globotickets")
        }
    }
}

struct ContentView_Previews: PreviewProvider {
    static var previews: some View {
        ContentView()
    }
}
