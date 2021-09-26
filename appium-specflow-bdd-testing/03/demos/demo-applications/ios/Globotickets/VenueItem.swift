//
/////  VenueItems.swift
//  Globotickets
//
//  Created by Marko Vajs on 22.6.21..
//

import Foundation

struct VenueItem : Identifiable {
    var id = Int()
    var title = String()
    var price = Double()
    var capacity = Int()
    
    init(id: Int, title: String, price: Double, capacity: Int) {
        self.id = id;
        self.title = title
        self.price = price
        self.capacity = capacity
    }
}
